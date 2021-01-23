    namespace TryOuts
    {
        using System;
        using System.Linq;
        using System.Threading.Tasks;
        using System.Windows.Forms;
        using System.Reactive.Linq;
        using System.Threading;
        // Simulated async search service, that can fail.
        public class FakeWordSearchService
        {
            private static Random _rnd = new Random();
            private static string[] _allWords = new[] {
                "gideon", "gabby", "joan", "jessica", "bob", "bill", "sam", "johann"
            };
            public async Task<string[]> Search(string searchTerm, CancellationToken cancelToken)
            {
                await Task.Delay(_rnd.Next(600), cancelToken); // simulate async call.
                if ((_rnd.Next() % 5) == 0) // every 5 times, we will cause a search failure
                    throw new Exception(string.Format("Search for '{0}' failed on purpose", searchTerm));
                return _allWords.Where(w => w.StartsWith(searchTerm)).ToArray();
            }
        }
        public static class RxAutoComplete
        {
            // Returns an observable that pushes the 'txt' TextBox text when it has changed.
            static IObservable<string> TextChanged(TextBox txt)
            {
                return from evt in Observable.FromEventPattern<EventHandler, EventArgs>(
                    h => txt.TextChanged += h,
                    h => txt.TextChanged -= h)
                    select ((TextBox)evt.Sender).Text.Trim();
            }
            // Throttles the source.
            static IObservable<string> ThrottleInput(IObservable<string> source, int minTextLength, TimeSpan throttle)
            {
                return source
                    .Where(t => t.Length >= minTextLength) // Wait until we have at least 'minTextLength' characters
                    .Throttle(throttle)      // We don't start when the user is still typing
                    .DistinctUntilChanged(); // We only fire, if after throttling the text is different from before.
            }
            // Provides search results and performs asynchronous, 
            // cancellable search with automatic retries on errors
            static IObservable<string[]> PerformSearch(IObservable<string> source, FakeWordSearchService searchService)
            {
                return from term in source // term from throttled input
                       from result in Observable.FromAsync(async token => await searchService.Search(term, token))
                            .Retry(3)          // Perform up to 3 tries on failure
                            .TakeUntil(source) // Cancel pending request if new search request was made.
                       select result;
            }
            // Putting it all together.
            public static void RunUI()
            {
                // Our simple search GUI.
                var inputTextBox = new TextBox() { Width = 300 };
                var searchResultLB = new ListBox { Top = inputTextBox.Height + 10, Width = inputTextBox.Width };
                var searchStatus = new Label { Top = searchResultLB.Height + 30, Width = inputTextBox.Width };
                var mainForm = new Form { Controls = { inputTextBox, searchResultLB, searchStatus }, Width = inputTextBox.Width + 20 }; 
                // Our UI update handlers.
                var syncContext = SynchronizationContext.Current;
                Action<Action> onUITread = (x) => syncContext.Post(_ => x(), null);
                Action<string> onSearchStarted = t => onUITread(() => searchStatus.Text = (string.Format("searching for '{0}'.", t)));
                Action<string[]> onSearchResult = w => { 
                    searchResultLB.Items.Clear(); 
                    searchResultLB.Items.AddRange(w);
                    searchStatus.Text += string.Format(" {0} maches found.", w.Length > 0 ? w.Length.ToString() : "No");
                };
                // Connecting input to search
                var input = ThrottleInput(TextChanged(inputTextBox), 1, TimeSpan.FromSeconds(0.5)).Do(onSearchStarted);
                var result = PerformSearch(input, new FakeWordSearchService());
                // Running it
                using (result.ObserveOn(syncContext).Subscribe(onSearchResult, ex => Console.WriteLine(ex)))
                    Application.Run(mainForm);
            }
        }
    }
