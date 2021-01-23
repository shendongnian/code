    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
        
    public static class Extensions
    {
        /// <summary>
        /// Creates a int array from a String.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>an Int Array</returns>
        public static IObservable<IEnumerable<int>> StringToIntArray(this string source)
        {
            return Observable.Create<IEnumerable<int>>(sub =>
            {
                var sourceAsStringArray = source.ToCharArray().Select(x => x.ToString());
                var l = new List<int>();
                foreach (var s in sourceAsStringArray)
                {
                    int output = -1;
                    if (int.TryParse(s, out output))
                    {
                        l.Add(output);
                    }
                }
    
                sub.OnNext(l);
                sub.OnCompleted();
                return Disposable.Empty;
            });
        }
        
    }
    
    private async void Test()
        {
           var a = await "12345".StringToIntArray();
           var b = await "1a234b5".StringToIntArray();
           var invalid = await "IAmNotANumber".StringToIntArray();
        }
