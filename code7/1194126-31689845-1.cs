    int[] nums = {0, 15, 18, 33, 61, 81, 89, 93, 94, 102, 110, 111, 114, 118 };
    string input = "Long string here";
    for (int i = 0; i < nums.Length - 1; i++)
    {
	    Console.WriteLine(input.Substring(nums[i], nums[i + 1] - nums[i]));
    }
