    public static class HelperExtension
    {
        public static IEnumerable<SingleItemDTO> ToDto(this IEnumerable<Tbl_itembundlecontents> items)
        {
            return items.Select(z => z.ToDto());
        }
        public static SingleItemDTO ToDto(this Tbl_itembundlecontents z)
        {
            return new SingleItemDTO
            {
                amount = z.amount,
                id = z.id,
                position = z.position,
                contentType = new BasicMaterialDTO
                {
                    id = z.tbl_items.id,
                    img = z.tbl_items.tbl_material.img,
                    name = z.tbl_items.tbl_material.name,
                    namekey = z.tbl_items.tbl_material.namekey,
                    info = z.tbl_items.tbl_material.info,
                    weight = z.tbl_items.tbl_material.weight
                }
            };
        }
    }
