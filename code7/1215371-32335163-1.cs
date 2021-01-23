    public class Person
    {
        public event EventHandler<BirthdayEventArgs> HappyBirthday;
        public int Age { get; set; }
        public string Name { get; set; }
        public void ItsMyBirthday()
        {
            if (HappyBirthday != null)
                HappyBirthday(this,
                    new BirthdayEventArgs(
                        string.Format("{0} birthday is today and is {1} years old!",
                        Name, Age)));
        }
    }
