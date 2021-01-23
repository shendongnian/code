    @helper PopulateTable(IList<EnterpriseServices.Vendor.Attachment> attachments)
    {
        <table>
            @foreach (var a in attachments)
            {
            string path = a.AttachmentPath;
            <tr>
                <td>
                    <a href=path>@Path.GetFileName(a.AttachmentPath)</a>
                </td>
            </tr>
            }
        </table>
    }
