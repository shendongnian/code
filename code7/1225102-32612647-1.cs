    @helper PopulateTable(IList<EnterpriseServices.Vendor.Attachment> attachments)
    {
        <table>
            @foreach (var a in attachments)
            {
            <tr>
                <td>
                    <a href="@a.AttachmentPath">@Path.GetFileName(a.AttachmentPath)</a>
                </td>
            </tr>
            }
        </table>
    }
