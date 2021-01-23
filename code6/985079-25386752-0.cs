    using Microsoft.SPOT.Hardware;
    using System;
    
    public class Program
    {
        public static void Main()
        {
            var interrupt = new InterruptPort(Cpu.Pin.GPIO_Pin0, true, Port.ResistorMode.PullUp, Port.InterruptMode.InterruptEdgeHigh);
            interrupt.OnInterrupt += interrupt_OnInterrupt;
    
            PowerState.Sleep(SleepLevel.DeepSleep, HardwareEvent.OEMReserved1);
    
            ///Continue on with your program here
        }
    
        private static void interrupt_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            //Interrupted
        }
    }
