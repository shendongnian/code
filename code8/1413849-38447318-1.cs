    using System.Linq;
    using System.Collections.Generic;
    
    private void button1_Click(object sender, EventArgs e)
    {
        List<int> numbers = new List<int>
        { 
            2, 6, 6, 5, 8, 1, 3, 3, 9, 3, 6, 1, 3, 9, 1, 7, 8, 6, 8, 1, 1,
            4, 4, 2, 8, 4, 5, 4, 6, 10, 1, 4, 3, 1, 2, 8, 4, 5, 9, 2, 2, 4 
        };
        int target = 27;
        sum_up(numbers, target);
    }
    private static void sum_up(List<int> numbers, int target)
    {
        sum_up_recursive(numbers, target, new List<int>(), 0);
    }
    private static void sum_up_recursive
        (List<int> numbers, int target, List<int> @partial, int index)
    {
        int s = @partial.Sum();
        if (s >= target && @partial.Count == 7)
        {
            Console.WriteLine("sum(" + string.Join(",", partial.ToArray()) + ")=" + target);
        }
        else if (s < target)
        {
            if( index + 7 > numbers.Count )
            {
                return;
            }
            else
            {
                List<int> partial_rec = numbers.GetRange(index, index + 7);
                sum_up_recursive(numbers, target, partial_rec, ++index);
            }
        }
    }
