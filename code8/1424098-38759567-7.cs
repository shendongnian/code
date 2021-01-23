    List<dynamic> Joints = new List<dynamic>
    {
        new { Id = 1, LineId = 1, JointName = "joint1" },
        new { Id = 2, LineId = 2, JointName = "joint2" },
        new { Id = 3, LineId = 1, JointName = "joint3" },
    };
    List<dynamic> Lines = new List<dynamic>
    {
        new { Id = 1, LineName = "line1" },
        new { Id = 2, LineName = "line2" },
        new { Id = 3, LineName = "line3" },
    };
    List<dynamic> FitUpDetails = new List<dynamic>
    {
        new { Id = 1, JointId = 1, FitUpdate = new DateTime(2012,12,12), State = "acc" },
        new { Id = 2, JointId = 1, FitUpdate = new DateTime(2013,12,12), State = "rej" },
        new { Id = 1, JointId = 2, FitUpdate = new DateTime(2015,12,12), State = "acc" },
        new { Id = 4, JointId = 2, FitUpdate = new DateTime(2016,12,12), State = "rej" },
    };
