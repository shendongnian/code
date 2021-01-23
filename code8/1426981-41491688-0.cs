        private static object MyMapperResolver(object source, bool returnEmptyString = true) {
            return source ?? (returnEmptyString ? "" : source);
        }
        public static IMapper InitMappings() {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Invoice, TempInvoice>()
                    .ForMember(des => des.PaymentID, map => map.ResolveUsing(src => MyMapperResolver(src.Id)))
                    .ForMember(des => des.InvoiceID, map => map.ResolveUsing(src => MyMapperResolver(src.Invoice.Id)))
                    .ForMember(des => des.PaymentDate, map => map.ResolveUsing(src => MyMapperResolver(src.Date, false)))
                    ;
            });
            return Mapper.Instance;
        }
