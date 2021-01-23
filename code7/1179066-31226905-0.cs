		private void btnGenerateScores_Click_1(object sender, EventArgs e)
		{
			int genTimes;
			if (Int32.TryParse(txtInputNumber.Text, out genTimes))
			{
				var ints = new List<int>();
				for (var i = 0; i < genTimes; i++)
				{
					var r = new Random(Guid.NewGuid().GetHashCode());
					var rInt = r.Next(0, int.MaxValue); //for ints
					ints.Add(rInt);
				}
				var copyInts = ints.ToList();
				copyInts.AddRange(this.listBox1.Items.Cast<int>());
				copyInts = copyInts.Distinct().OrderBy(x => x).ToList();
				this.listBox1.Items.Clear();
				this.listBox1.Items.AddRange(copyInts.Cast<object>().ToArray());
				MessageBox.Show("The random number generated is: " + String.Join(",", ints));
			}
		}
	}
