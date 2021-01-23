    public override void Unload()
    {
        this.Kernel.Get<Ifoo>().Dispose();
        base.Unload();
    }
