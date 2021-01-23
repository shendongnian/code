    static void Main(string[] args)
            {
    try{
                // Create a NXT brick,
                // and use Bluetooth on COM40 to communicate with it.
                NxtBrick brick = new NxtBrick(NxtCommLinkType.USB, 0);
    
            // Attach motors to port B and C on the NXT.
            brick.MotorB = new NxtMotor();
            brick.MotorC = new NxtMotor();
    
    
            // Connect to the NXT.
            brick.Connect();
    
            // Run them at 75% power, for a 3600 degree run.
            brick.MotorB.Run(75, RobotArmR);
            brick.MotorC.Run(75, RobotArmL);
    
            // Disconnect from the NXT.
            brick.Disconnect();
    }
    catch(Exception ex){}
        }
