    // populate the array
	nums[0] = Int32.Parse(textBox1.Text);
    nums[1] = Int32.Parse(textBox2.Text);
    nums[2] = Int32.Parse(textBox3.Text);
    nums[3] = Int32.Parse(textBox4.Text);
    nums[4] = Int32.Parse(textBox5.Text);
	
    // sort the array from lowest to highest
	Array.Sort(nums);
	
    // declare a variable to hold the sum
	int sum = 0;
	
	// iterate over the first (smallest) three
	for(int i=0;i<3; i++)
	{
	   sum += nums[i];
	}
    Console.WriteLine("The sum of the three smallest is: " + sum);
