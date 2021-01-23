    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int volume = 52;
                int l=0, w=0, h=0, minval=int.MaxValue;
                for (int length = 1; length <= volume; length++)
                {
                    for (int width = 1; width <= volume; width++)
                    {
                        for (int height = 1; height <= volume; height++)
                        {
                            if(length * width * height >= volume){
                                int area = 2*(length*width + width*height + length*height);
                                if(area < minval){
                                    l=length;
                                    w=width;
                                    h=height;
                                    minval = area;
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("length = " + l + ", width= " + w + ", height = " + h);
            }
        }
    }
