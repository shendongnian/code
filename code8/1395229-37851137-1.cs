    StringBuilder sb = new StringBuilder();
    bool isFollowing = false;
    foreach (var item in listboxColor.SelectedItems)
    {
        if (isFollowing)
        {
            sb.Append(", ");
        }
        else
        {
            isFollowing = true;
        }
        sb.Append(item);
    }
    string colors = sb.ToString();
