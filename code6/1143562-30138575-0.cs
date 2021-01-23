	private void Activate_Click(object sender, EventArgs e)
	{
		var sab = switchAB.Text;
		var sc = switchC.Text;
		var sde = switchDE.Text;
		var sf = switchF.Text;
		var sg = switchG.Text;
		var sh = switchH.Text;
		var tb1 = textBox1.Text;
		Task task = new Task(() => mng.start(sab, sc, sde, sf, sg, sh, tb1));
		task.Start();
	}
