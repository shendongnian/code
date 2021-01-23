    public partial class MyTableAdapter
    {
        public string ConnectionString
        {
            set
            {
                if ((this._commandCollection == null))
                {
                    this.InitCommandCollection();
                }
                for (int index = 0; index < this._commandCollection.Length; index++)
                {
                    this._commandCollection[index].Connection.ConnectionString = value;
                }
            }
        }
    }
