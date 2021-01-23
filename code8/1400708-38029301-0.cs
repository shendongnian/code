        public interface IBatchTextWriter : 
        {
        	TextWriter TextWriter { get; }
        	/// <summary>
        	/// Ends the batch (everything written to the <see cref="TextWriter"> will be written to the actual stream).
        	void EndBatch();
        }
        
