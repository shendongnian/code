    File f = File.Create("<YourMP3.mp3>"); // Remember to change this...
    TagLib.Id3v2.Tag t = (TagLib.Id3v2.Tag)f.GetTag(TagTypes.Id3v2); // You can add a true parameter to the GetTag function if the file doesn't already have a tag.
    PrivateFrame p = PrivateFrame.Get(t, "CustomKey", true);
    p.PrivateData = System.Text.Encoding.Unicode.GetBytes("Sample Value");
    f.Save(); // This is optional.
