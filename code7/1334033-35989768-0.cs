                    // find the content 
                    ImagePart imagePart = (ImagePart)slide.GetPartById(embedId);
                    if (imagePart != null)
                    {
                        d.Transform2D transform =  picture.Descendants<d.Transform2D>().First();
                        transform.Extents.Cx = 800000; // replace with correct calcualted values eventually
                        transform.Extents.Cy = 400000; // replace with correct calculated values eventually
                        using (FileStream fileStream = new FileStream(newImagePath, FileMode.Open))
                        {
                            imagePart.FeedData(fileStream);
                            fileStream.Close();
                        }
                        return; // found the photo and replaced it. 
                    }
