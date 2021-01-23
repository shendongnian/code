    var report = probing.Measurements.Export()
                .Column(MeasurementResource.Depth, m => m.Depth)
                .Column(MeasurementResource.DepthBelowWater, m => m.DepthBelowWater)
                .Column(MeasurementResource.ResistancePoint, m => m.ResistancePoint)
                .Column(MeasurementResource.FrictionLateral, m => m.FrictionLateral)
                .Column(MeasurementResource.FrictionLocal, m => m.FrictionLocal)
                .Column(MeasurementResource.FrictionTotal, m => m.FrictionTotal)
                .Column(MeasurementResource.Inclination, m => m.Inclination)
                .Column(MeasurementResource.PoreWaterPressure, m => m.PoreWaterPressure)
                .Column(MeasurementResource.Speed, m => m.Speed)
                .Column(MeasurementResource.CalcAlpha, m => m.CalcAlpha)
                .Column(MeasurementResource.CalcGammaDry, m => m.CalcGammaDry)
                .Column(MeasurementResource.CalcGammaWet, m => m.CalcGammaWet)
                .Column(MeasurementResource.GrainTension, m => m.GrainTension)
                .Column(MeasurementResource.CompressionCoefficient, m => m.CompressionCoefficient)
                .ToReport(null, new ExcelReportWriter());
            var stream = new MemoryStream();
            writer.WriteReport(report, stream);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/vnd.ms-excel", string.Format(@"{0}-{1}.xlsx", probing.Project.ProjectNumber, probing.ProbingNumber));
