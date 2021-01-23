class ErrorSuppressingStream : Stream
{
    private readonly Stream inner;
    public bool TerminatedWithError { get; private set; }
    public ErrorSuppressingStream(Stream inner) { this.inner = inner; }
    public override int Read(byte[] buffer, int offset, int count)
    {
        if (this.TerminatedWithError) { return 0; }
        try { return this.inner.Read(buffer, offset, count); }
        catch (XXXException ex)
        {
            this.TerminatedWithError = true;
            return 0;
        }
    }
    // more overrides here
}
