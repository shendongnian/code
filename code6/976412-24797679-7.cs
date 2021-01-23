cs  
using (WebClient client = new WebClient()) 
{
	client.DownloadFile(new Uri(url), @"c:\temp\image35.png");
	// OR 
	client.DownloadFileAsync(new Uri(url), @"c:\temp\image35.png");
}
These methods are almost same as DownloadString(..) and DownloadStringAsync(...). They store the file in Directory rather than in C# string and no need of Format extension in URi
If You don't know the Format(.png, .jpeg etc) of Image
------------------------------------------------------
cs
public void SaveImage(string filename, ImageFormat format)
{    
	WebClient client = new WebClient();
	Stream stream = client.OpenRead(imageUrl);
	Bitmap bitmap;  bitmap = new Bitmap(stream);
	if (bitmap != null)
	{
		bitmap.Save(filename, format);
	}
        
	stream.Flush();
	stream.Close();
	client.Dispose();
}
   
Using it
--------
cs
try
{
	SaveImage("--- Any Image Path ---", ImageFormat.Png)
}
catch(ExternalException)
{
	// Something is wrong with Format -- Maybe required Format is not 
	// applicable here
}
catch(ArgumentNullException)
{ 	
	// Something wrong with Stream
}
