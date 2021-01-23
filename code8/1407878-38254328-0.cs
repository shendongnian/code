    public class Note : INotifyPropertyChanged
    {
        public Note Clone()
        {
            return new Note()
            {
                Text = this.Text
            };
        }
        //... The rest stays the same
    }
