    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    private void Button_Click_5(object sender, RoutedEventArgs e)
    {
        var move1 = new ObjectToMove();
        Animation_Path.Children.Add(move1);
        var storyBoardsToRun = new[] {"Storyboard1", "Storyboard2"};
        storyBoardsToRun 
            .Select(sbName => FindResource(sbName) as Storyboard)
            .ToList()
            .ForEach(async sb => await sb.BeginAsync(move1));
    }
    public static class StoryBoardExtensions
    {
        public static Task BeginAsync(this Storyboard sb, FrameworkContentElement element)
        {
            var source = new TaskCompletionSource<object>();
            sb.Completed += delegate
            {
                source.SetResult(null);
            };
            sb.Begin(element);
            return source.Task;
        }
    }
