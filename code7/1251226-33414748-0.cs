    string xml = @"<tile>
       <x>0</x>
       <y>1</y>
       <name>Grass</name>
       <entity>Tree</entity>
       <entity>Building</entity>
       <entity>Something</entity>
    </tile>";
    
    var data = from t in XElement.Parse(xml).DescendantsAndSelf("tile")
    select new {
       X=(int)t.Element("x"),
       Y=(int)t.Element("y"),
       Name=(string)t.Element("name"),
       Entities= t.Elements("entity").Select (x => x.Value)
    };
