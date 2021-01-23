    double[] Points =  new double[] {
                    0,0,                0,0,
                    0,500,              50,500,
                    0,1000,             0,1000,
                    420,0,              420,0,
                    420,500,            370,500,
                    420,1000,           420,1000
                };
                MagickImage image = new MagickImage("E:/ImageManipulation/WebApplication2/images/Test.jpg");
                image.Distort(DistortMethod.Shepards,Points);
                image.Write("E:/ImageManipulation/WebApplication2/images/Result.jpg");
