    using System.Reactive.Linq;
    var list = new List<KeyValuePair<string, int>>();
    var series= Observable.Range(1, 100).Publish();
    series.Where(e => e % 2 == 0).Subscribe(e=>list.Add(new KeyValuePair<string, int>("Even",e)));
    series.Where(e => e % 2 == 1).Subscribe(e => list.Add(new KeyValuePair<string, int>("Odd", e)));
    series.Where(e => MyStaticMethods.IsPrime(e) ).Subscribe(e => list.Add(new KeyValuePair<string, int>("Prime", e)));
    series.Connect();
    var result = list.GroupBy(n => n.Key);
