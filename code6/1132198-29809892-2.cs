    public class Addressbook
    {
        private string[,] _fullname;
        private int _cnt;
        public Addressbook()
        {
           // Questions:
           // Are 10 fields really needed for firstName and lastName?
           // What if a user adds more than 10 names.
            _fullname = new string[10, 10]; 
        }
        public void AddAddress(string firstName, string lastName)
        {
            _fullname[_cnt,0] = firstName;
            _fullname[_cnt,1] = lastName;
            Console.WriteLine("Name: {0} {1} added.", _fullname[_cnt, 0], _fullname[_cnt, 1]);
            _cnt = _cnt + 1;
        }
        public void ViewAddresses()
        {
            Console.WriteLine("count is: {0}", _cnt);
            for (int i=0; i < _cnt; i++) 
            {
               Console.WriteLine("counter = {0}",i );
               Console.WriteLine("Name: {0} {1} ", _fullname[i,0], _fullname[i,1] );
            }
        }
    }
