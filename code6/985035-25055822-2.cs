        public Microsoft.SPOT.Hardware.PWM PWM {get;set;}
        public bool PwmBool
        {
            get
            {
                return false;
            }
            set
            {
                this.PWM = new PWM(Cpu.PWMChannel.PWM_4, 10, 0.5, value);
            }
        }
