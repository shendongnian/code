    public class Result<T>
    {
        private List<T> _vaguelist;
        public List<T> vaguelist {
            get
            {
                return _vaguelist;
            }
            set
            {
                _vaguelist = value;
            }
        }
    }
    public abstract class Result
    {
        public static Result<T> NewResultFromItem<T>(T item)
        {
            Result<T> result = new Result<T>();
            result.vaguelist.Add(item);
            return result;
        }
    }
    string item1 = "123";
    string item2 = "234";
    var result = Result.NewResultFromItem(item1);
    result.vaguelist.Add(item2);
