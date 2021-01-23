    var pres1 = new Classes.Prescricao()
            {
                DataEmissao = DateTime.Now,
                DataLimite = DateTime.Now.AddMonths(1),
                Descricao = "Prescrição teste.",
                Medico = m1,
                Paciente = p1,
                Status = Classes.PrescricaoStatus.Pendente
            };
    var r1 = new Classes.Remedio()
            {
                NomeComercial = "Aspirina",
                PrecoMedio = 12.49m,
                PrincipioAtivo = "Whatever",
                Status = Classes.RemedioStatus.Aprovado
            };
            context.Remedios.Add(r1);
            pres1.Remedios.Add(r1);
            context.Prescricoes.Add(pres1);
