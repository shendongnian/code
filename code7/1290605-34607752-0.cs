    interface ITreeNodeNG
    {
        object Id { get; set; }
        object ParentId { get; set; }
    }
    interface ITreeNodeP<TKey> where TKey : struct
    {
        TKey? Id { get; set; }
        TKey? ParentId { get; set; }
    }
    interface ITreeNodeC<TKey>
    {
        TKey Id { get; set; }
        TKey ParentId { get; set; }
    }
    public class X : ITreeNodeP<int>, ITreeNodeNG
    {
        public int? Id { get; set; }
        public int? ParentId { get; set; }
        object ITreeNodeNG.Id
        {
            get
            {
                return this.Id;
            }
            set
            {
                this.Id = (int)value;
            }
        }
        object ITreeNodeNG.ParentId
        {
            get
            {
                return this.ParentId;
            }
            set
            {
                this.ParentId = (int?)value;
            }
        }
    }
    static void Main(string[] args)
    {
        ITreeNodeNG x = new X();
        ITreeNodeP<int> y = new X();
        ITreeNodeC<string> z = null; // you know what to do
    }
