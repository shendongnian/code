    static public List<List<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        var res = new List<List<int>>();
        for (int i = 0; i < nums.Length; ++i)
        {
            for (int j = i + 1; j < nums.Length; ++j)
            {
                if (nums[i] == nums[j]) { ++i; }
                int c = Array.BinarySearch(nums, j + 1, nums.Length - j - 1, -nums[i] - nums[j]);
                if (c > j)
                {
                    res.Add(new List<int> { nums[i], nums[j], nums[c] });
                }
            }
        }
        return res;
    }
