    public interface IRobotRepository()
    {
        IEnumerable<Robot> GetAllRobots();
        Robot GetRobot(RobotParameters parameters);
        void DeleteRobots();
        void DeleteRobot(Robot robotToDelete);
    }
