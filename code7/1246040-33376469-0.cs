    public class LocalizationConverter : IValueConverter
    {
        public object Convert(
            object value, 
            Type targetType, 
            object parameter, 
            string language)
        {
            string valueString = value as string;
            var paramString = parameter as string;
            //so here you have the value of your binding in the value string
            //and if it's empty (because you don't want to use the bound value
            //you're setting the value string to be the param string
            if (string.IsNullOrWhiteSpace(valueString))
            {
                valueString = paramString;
            }
            //if value string (formerly your param string is empty just return
            //there is no value to be found
            if (string.IsNullOrWhiteSpace(valueString))
            {
                return null;
            }
            //now the fun starts :) ,I pass values with small command and 
            //separator symbol to be able to parse my parameters
            //something like this:
            //if (paramString.StartsWith("AddAfter|"))
            //{
            //    var valToAppend = paramString.Substring("AddAfter|".Length);
            //    return Strings.Get(Strings.Get(valToAppend + valueString));
            //}
            //and this basically does -> append the given parameter string after 
            //the part with the command to the value that comes from the binding
            //and then uses the resulting string from res dictionary 
            //So you could do something like passing "ToyType|Block" or you can
            //pass something in the value like Block and then in the parameters
            //have description ToyType or even pass not string object and get
            //what you want from it like
            //if(value is ToyType)
            //{
            //    return StringsGet((value as ToyType).Name)
            //}
            //Your parsing logic HERE
            //This is how we get strings from resources in our project
            //that you already know how to do
            return Strings.Get(valueString);
        }
        public object ConvertBack(
            object value,
            Type targetType, 
            object parameter, 
            string language)
        {
            throw new NotImplementedException();
        }
    }
