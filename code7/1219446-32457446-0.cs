    public struct Time
    {
    private int hours;
    private int minutes;
    public Time(int hh, int mm)
    {
        this.hours = hh;
        this.minutes = mm;
    }
    public int hh { get { return hours; } set { hours = value % 60; } }
    public int mm { get { return minutes; } set { minutes = value % 60; } }
    public override string ToString()
    {
        return String.Format("{0:00}:{1:00}", hh, mm);
    }
    public static implicit operator Time(int t)
    {
        int hours = (int)t / 60;
        int minutes = t % 60;
        return new Time(hours, minutes);
    }
    public static explicit operator int(Time t)
    {
        return t.hours * 60 + t.minutes;
    }
    public static Time operator +(Time t1, int num)
    {
        int total = t1.hh * 60 + t1.mm + num;
        int h = (int)(total / 60) % 24,
            m = total % 60;
        return new Time(h, m);
    }
    public int Minutes { get { return minutes; } set { minutes = value % 60; } }
    class Program
    {
        static void Main(string[] args)
        {
            Time t1 = new Time(9, 30);
            Time t2 = t1;
            t1.minutes = 100;
            Console.WriteLine("The time is: \nt1={0}  \nt2={1} ", t1, t2);
            Time t3 = t1 + 45;
        }
    }
    }
