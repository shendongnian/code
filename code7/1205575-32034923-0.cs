    public static void Extract(Bitmap imageToExtract, string destination) {
        System.IO.File.WriteAllBytes(
            destination, 
            ImageToByte(
                imageToExtract
            )
        );
    }
