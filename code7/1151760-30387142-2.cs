    var list = new List<Config>();
    public class Config{
       string LabelText
       string LabelValue
    }
    while ((line = file.ReadLine()) != null)
    {
        //Split the line based on the pattern and build the list object for Labeltext and LabelValue.
        //You will have to come up with the logic to split the line into string based on the pattern. Where text in the [] is LabelTesxt and anything followed after ] is  LabelValue
        list.Add(new Config{LavelText = "VERSION" ,LabelValue="7544"});
       
        counter++;
    }
    //Once done, you could bind the data to the label
    var item = list.Find(item => item.LabelText == "VERSION");
    lblVersionLabel.Text = item.LabelValue
