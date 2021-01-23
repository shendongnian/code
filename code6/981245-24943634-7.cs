c#
List<ProcessInfo> processes = new List<ProcessInfo>();
using(StreamReader reader = new StreamReader("input.txt'))
{
    reader.ReadLine(); //The headers don't matter!
    string currentLine;
    while (currentLine = reader.ReadLine() != null)
    {
        ProcessInfo newInfo = new ProcessInfo();
        //Actual parsing left up to the reader; String.Split is your friend.
        processes.Add(newInfo);
    }
}
Finally, we need to set up the XAML:
xml
<ListView ItemsSource="{Binding Processes}">
    <ListView.View>
        <GridView>
            <GridViewColumn DisplayMemberBinding="{Binding Name}" Header="Name"/>
          ...
        </GridView>
    </ListView.View>
</ListView>
Bind each column to a property in the `ProcessInfo` class. I included a sample for the first column. Of course, you need to expose the parsed collection as a public property of your View Model for this to work.
