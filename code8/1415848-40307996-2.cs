    public async Task<ActionResult> AddPicture(int? id, HttpPostedFileBase file)
    {
        ....
                Bitmap Thumbnail = await ResizeImage(FinalBitmap, 150, 150);
                Bitmap FullPicture = await ResizeImage(FinalBitmap, 800, 600);
        ....
    }
	
	
    public async Task<Bitmap> ResizeImage(Image image, int width, int height)
    {
		....
                await Task.Run(()=>{ graphics.DrawImage(....) });
        ...
}
