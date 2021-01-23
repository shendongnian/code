    public class Test<T> where T : Exception
    {
        public virtual void Build_ReturnsSpecificException_FileNamePassedIn(
            string fileName,
            ProcessFactory sut)
        {
            Assert.Throws<T>(() => sut.Build(fileName));
        }
    }
