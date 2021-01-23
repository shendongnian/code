    Teacher teacher = Load();
    if (teacher != null)
    {
        tNametxtBox.Text = teacher.Name1;
        tIDtxtBox.Text = teacher.ID1;
    }
    else
    {
        // Error load XML
    }
