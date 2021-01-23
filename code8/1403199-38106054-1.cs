        public class Program
        {
            static public List<List<int>> ThreeSum(int[] nums)
            {
                Array.Sort(nums);
                var res = new List<List<int>>();
                for (int i = 0; i < nums.Length; ++i)
                {
                    for (int j = i + 1; j < nums.Length; ++j)
                    {
                        int c = Array.BinarySearch(nums, j + 1, nums.Length - j - 1, -nums[i] - nums[j]);
                        if (c > j)
                        {
                            res.Add(new List<int> { nums[i], nums[j], nums[c] });
                        }
                        while (j < nums.Length - 1 && nums[j] == nums[j + 1])
                            j++;
                    }
                    while (i < nums.Length - 1 && nums[i] == nums[i + 1])
                        i++;
                }
                return res;
            }
            static public void printThreeSum(List<List<int>> list)
            {
                foreach (var item in list)
                {
                    foreach (var t in item)
                    {
                        Console.Write(t.ToString() + " ");
                    }
                    Console.Write("\n");
                }
                Console.Write("\n");
            }
            static void Main(string[] args)
            {
                printThreeSum(ThreeSum(new int[] { 0, 0, 0 }));
                printThreeSum(ThreeSum(new int[] { 0, 0, 0, 0 }));
                printThreeSum(ThreeSum(new int[] { 0, 0, 0, 0, 0 }));
                printThreeSum(ThreeSum(new int[] { -1, -1, 2 }));
                printThreeSum(ThreeSum(new int[] { -1, -1, -1, -1, 2, 2, 2 }));
                printThreeSum(ThreeSum(new int[] { -2, -1, -1, 1, 1, 1, 1 }));
                printThreeSum(ThreeSum(new int[] { -2, -1, 0, 1, 2 }));
            }
        }
