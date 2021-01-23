	[SerializeField] private RawImage _rawImage;
	public void DownloadImage(string url)
	{
		StartCoroutine(DownloadImageCoroutine(url));
	}
	private IEnumerator DownloadImageCoroutine(string url)
	{
		using (WWW www = new WWW(url))
		{
			// download image
			yield return www;
			// if no error happened
			if (string.IsNullOrEmpty(www.error))
			{
				// get texture from WWW
				Texture2D texture = www.texture;
				yield return null; // wait a frame to avoid hang
				// show image
				if (texture != null && texture.width > 8 && texture.height > 8)
				{
					_rawImage.texture = texture;
				}
			}
		}
	}
