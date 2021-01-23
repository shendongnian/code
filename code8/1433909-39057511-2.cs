        for(int i = 0; i < width * height; ++i)
        {
            if(line <= 0) {line = 150; Console.Write("\r\n");}
            else if (line < 150) Console.Write(" ");
            line--;
            Vec3f pixel = GetColor(image[i]);
            Console.Write(pixel.x + " " + pixel.y + " " + pixel.z);
        }
