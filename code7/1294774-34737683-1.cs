    List<string> fileNames = new List<string>(); //suppose you have names of files in a list
    foreach(var name in fileNames)
    {
        if(checkBox.IsChecked)
        {
            Records[name].ReplaceContents
            ("images/disabled/" + name, "images\\disabled\\" + name, content.FileRoot);
        }
        else
        {
            Records[name].ReplaceContents
            ("images/enabled/" + name, "images\\enabled\\" + name, content.FileRoot);
        }
    }
