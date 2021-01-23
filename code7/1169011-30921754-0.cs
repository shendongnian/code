        //Base URL. Doesn't need to be hardcoded. As long as it contains "objectIds=" then it will work
        static string url = @"http://www.GoodStuff.xxx/services/stu/query?where=1%3D1&text=&objectIds=231699%2C232002%2C231700%2C100646&time=";
      
        static void Main(string[] args)
        {
            //Get the start index
            // +10 because IndexOf gets us to the o but we want the index of the equal sign
            int startIndex = url.IndexOf("objectIds=") + 10;
            //Figure out how many characters we are skipping over.
            //This is nice because then it doesn't matter if the value of objectids is 0 or 99999999
            int endIndex = url.Substring(startIndex).IndexOf('&');
            //Cache the second half of the URL
            String secondHalfOfURL = url.Substring(startIndex + endIndex); 
            //Our new IDs to stick in
            int newObjectIDs = 12345;
            //The new URL. 
            //First, we get the string up to the equal sign of the objectIds value
            //Next we put our IDS in.
            //Finally we add on the second half of the URL
            String NewURL = url.Substring(0, startIndex) + newObjectIDs + secondHalfOfURL;
            Console.WriteLine(NewURL);
           
            Console.Read();
        }
