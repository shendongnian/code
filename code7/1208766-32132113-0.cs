    string content = txtNumbers.Text;
    string[] splitContent = content.Split(new char[] { ',' });
    int[] nums = new int[splitContent.Length];
    for (int i = 0; i < splitContent.Length; i++)
    {
        nums[i] = Int32.Parse(splitContent[i]);
    }
