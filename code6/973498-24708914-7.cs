    public class MyDocViewModel: GenericListViewModel<DocView>
    {
        public MyDocViewModel()
            : base(
            (list) =>
            {
                return list.Sum(x => x.Price);
            },
            (list) =>
            {
                return list.Count;
            }
            )
        {
        }
    }
