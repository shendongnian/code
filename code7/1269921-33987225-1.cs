    string text = Console.ReadLine();
    string newText = "";
    string ommit = "AaSsNn"; // should not remove these.
   
    for (int i = 0; i < text.Length; i++)
    {
        if (ommit.Contains(text[i])) // if character exist in ommit.
        {
            newText += text[i]; // put the original
        }
        else
        {
            newText += "*"; // replace
        }
    }
