    public class ItemWrappingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object param, CultureInfo cultur)
        {
            var persons = value as IEnumerable<Person>;
            if (persons == null) return null;
            return persons.Select(person => new PersonWrapper()
            {
                Person = person,
                FullName = GetFullName(person.FirstName, person.LastName)
            } );
        }
        public object ConvertBack(object value, Type targetT, object param, CultureInfo culture)
        { throw new NotSupportedException(); }
    }
    public class PersonWrapper
    {
        public Person Person { get; set; }
        public string FullName { get; set; }
    }
