    builder.RegisterType<FileStreamFactory>()
                .As<IFileStreamFactory>()
                .Exported(x => x.As<IFileStreamFactory>());
    builder.RegisterType<XmlWriterFactory>()
                .As<IXmlWriterFactory>()
                .Exported(x => x.As<IFileStreamFactory>());
