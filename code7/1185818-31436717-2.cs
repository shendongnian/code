    public class UndoTrack
    {
        public UndoTrack(Track track)
        {
            this.TrackToUndo = track;
            this.UndoId = track.CloneId;
            this.CreatedAt = DateTime.Now;
        }
        public Track TrackToUndo {get; set;}
        public Guid UndoId {get; set;}
        public DateTime CreatedAt {get; set;}
    }
