    DateTime date = DateTime.FromOADate(42491);
    string str = date.ToString("d-M-yyyy");
    Console.WriteLine(str);
    //CultureInfos
    CultureInfo ciGB = new CultureInfo("en-GB", false);
    CultureInfo ciUS = new CultureInfo("en-US", false);
    //ToDateTime version
    DateTime dateGB = Convert.ToDateTime(str, ciGB);
    DateTime dateUS = Convert.ToDateTime(str, ciUS);
    Console.WriteLine("ToDateTime: GB = {0}, US = {1}", dateGB, dateUS);
    //ParseExact version
    DateTime parsedGB = DateTime.ParseExact(str,"d-M-yyyy", ciGB);
    DateTime parsedUS = DateTime.ParseExact(str, "M-d-yyyy", ciUS);
    Console.WriteLine("ParseExact: GB = {0}, US = {1}", parsedGB, parsedUS);
    //Manual parsing
    var parts = str.Split('-');
    int item1 = int.Parse(parts[0]);
    int item2 = int.Parse(parts[1]);
    int item3 = int.Parse(parts[2]);
    DateTime manualGB = new DateTime(item3, item2, item1);
    DateTime manualUS = new DateTime(item3, item1, item2);
    Console.WriteLine("Manual: GB = {0}, US = {1}", manualGB, manualUS);
