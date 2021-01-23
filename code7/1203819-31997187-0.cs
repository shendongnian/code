    Bitmap Source; //your Bitmap
    Image<Bgr, byte> ImageFrame = new Image<Bgr, byte>(Source); //image that stores your bitmap
    Image<Gray, byte> grayFrame = ImageFrame.Convert<Gray, byte>(); //grayscale of your image
    HaarCascade haar = new HaarCascade("yourhaarcascadefile.xml"); //the object used for detection
    var faces = grayFrame.DetectHaarCascade(haar, 1.1, 3, HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new System.Drawing.Size(25, 25))[0]; //variable that stores detection information
    foreach (var face in faces) 
        ImageFrame.Draw(face.rect, new Bgr(System.Drawing.Color.Green), 3); //draws a rectangle on top of your detection
    return ImageFrame.toBitmap(); //returns your bitmap with detection applied;
