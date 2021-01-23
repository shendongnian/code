    public class MyMailItem
    {
        private readonly string _sender;
        private readonly int _size;
        private readonly string _subject;
        private DateTime _creationTime;
        public MyMailItem(MailItem mail)
        {
            Mail = mail;
            _sender = Mail.SenderEmailAddress;
            _size = Mail.Size;
            _subject = Mail.Subject;
            _creationTime = Mail.CreationTime;
        }
        public MailItem Mail { get; private set; }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((MyMailItem)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_sender != null ? _sender.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _size;
                hashCode = (hashCode * 397) ^ (_subject != null ? _subject.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _creationTime.GetHashCode();
                return hashCode;
            }
        }
        protected bool Equals(MyMailItem other)
        {
            return string.Equals(_sender, other._sender) && _size == other._size && string.Equals(_subject, other._subject) &&
                   _creationTime.Equals(other._creationTime);
        }
