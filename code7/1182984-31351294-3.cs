    using System.IO;
    abstract class BaseClass
    {
        protected abstract void WriteToTextWriter(TextWriter textWriter);
        public void SerializeTo(TextWriter textWriter)
        {
            WriteToTextWriter(textWriter);
        }
        public sealed override string ToString()
        {
            var writer = new StringWriter();
            SerializeTo(writer);
            return writer.ToString();
        }
    }
    abstract class ChunkBase : BaseClass
    {
        private readonly string _index;
        protected ChunkBase(string index)
        {
            _index = index;
        }
        protected sealed override void WriteToTextWriter(TextWriter textWriter)
        {
            textWriter.Write("Chunk");
            textWriter.Write(_index);
        }
    }
    class Chunk1 : ChunkBase { public Chunk1() : base("1") { } }
    class Chunk2 : ChunkBase { public Chunk2() : base("2") { } }
    class Chunk3 : ChunkBase { public Chunk3() : base("3") { } }
    class ClassWithChunks : BaseClass
    {
        private readonly Chunk1 _chunk1 = new Chunk1();
        private readonly Chunk2 _chunk2 = new Chunk2();
        private readonly Chunk3 _chunk3 = new Chunk3();
        protected override void WriteToTextWriter(TextWriter textWriter)
        {
            _chunk1.SerializeTo(textWriter);
            _chunk2.SerializeTo(textWriter);
            _chunk3.SerializeTo(textWriter);
        }
    }
