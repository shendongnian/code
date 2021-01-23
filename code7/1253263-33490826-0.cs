	textBox1.Text = 
		// this is the outer, final stage that converts the line collection to text
		string.Join("\r\n", 
			// start with a list of numbers, no more than the smallest item count
			// (for the supplied data this is [0..5])
			Enumerable.Range(0, Math.Min(listBox1.Items.Count, listBox2.Items.Count))
			// use those to index the Items collections on your listboxes
			.Select(i => new { tag = listBox1.Items[i].ToString(), value = double.Parse(listBox2.Items[i].ToString()) })
			// group the values by the tag character
			.GroupBy(row => row.tag.Substring(0,1), r => r.value)
			// aggregate and produce a line for each group
			.Select(grp => string.Format("Group: {0}, Count: {1}, Average: {2}", grp.Key, grp.Count(), grp.Average()))
			// sort output - this is optional and probably unnecessary
			.OrderBy(r=> r)
		);
