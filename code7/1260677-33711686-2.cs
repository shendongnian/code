        class Program
        {
            static void Main(string[] args)
            {
                Gun myGun = new AK();
                Console.WriteLine(myGun.load(new AK_Mag())); // true
                Console.WriteLine(myGun.load(new ShotGun_Mag())); // false
                func2();
            }
    
            static Gun someGun;
            static void func1(Gun gun)
            {
                someGun = gun; 
            }
    
            public static void func2()
            {
                Gun someAK = new AK();
                someAK.load(new AK_Mag());
                func1(someAK);
            }
        }
    
        public class AK : Gun
        {
            public bool load(Mag mag)
            {
                if (mag == null)
                    return false;
                if ( mag.GetType() != typeof(AK_Mag))
                {
                    return false;
                }
    
                return true;
            }
    
            public void shoot(int x, int y, int z)
            {
                throw new NotImplementedException();
            }
            public bool setFireMode(Gun.FireMode mode)
            {
                this.mode = mode;
                return true;
            }
        }
    
        public class AK_Mag : Mag
        {
            public int Remain()
            {
                throw new NotImplementedException();
            }
        }
    
        public class ShotGun_Mag : Mag
        {
            public int Remain()
            {
                throw new NotImplementedException();
            }
        }
    
        public interface Gun
        {
            public enum FireMode { Manual, Burst };
            bool load(Mag mag);
            void shoot(int x, int y, int z);
            bool setFireMode(FireMode mode);        
        }
    
        public interface Mag
        {
            int Remain();
        }
