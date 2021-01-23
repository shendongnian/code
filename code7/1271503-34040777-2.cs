	var hash = System.Security.Cryptography.MD5.Create();
	var stringtoHash = "3490518cvm90wg89puse5gu3tgu3v0afgmvkldfjgmvvvvvsh,9semc9petgucm9234ucv0[vhd,flhgvzemgu904vq2m0";
	var sw = System.Diagnostics.Stopwatch.StartNew();
	for(var i = 0; i < 60000; i++)
	{
		var bytesToHash = Encoding.UTF8.GetBytes(stringtoHash);
	    var hashedBytes = hash.ComputeHash(bytesToHash);
	    var signature = Encoding.UTF8.GetString(hashedBytes);
	}
	sw.Stop();
	Console.WriteLine(sw.ElapsedMilliseconds);
