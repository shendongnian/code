    var result = QL.HopDongCungCaps.Select(x => new
            {
                MaHD = x.MaHD,
                TenHD = x.TenHD,
                ThoiHan = x.ThoiHan,
                NCC = x.NCC
            }).ToList();
