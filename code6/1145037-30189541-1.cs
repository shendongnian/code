		private void button1_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < ClassArray.ar2.Length; i++)
			{
				AddElement(i);
				if (ClassArray.ar2[i] == "3")
				{
					Form2 frm2 = new Form2(counter);
					// ShowDialog will stop code execution until dialog is closed
					frm2.ShowDialog(this); // "this" - will be a Dialog Owner; it will come in handy in Form2
					i++; // skip "4"
				}
			}
		}
